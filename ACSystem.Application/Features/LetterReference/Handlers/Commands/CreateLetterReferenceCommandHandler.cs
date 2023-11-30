using ACSystem.Application.Contracts.Persistence;
using ACSystem.Application.DTOs.LetterType.Validator;
using ACSystem.Application.DTOs.LetterType;
using ACSystem.Application.Features.LetterReference.Requests.Commands;
using ACSystem.Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACSystem.Application.DTOs.LetterReference.Validator;
using ACSystem.Application.Contracts.Service;
using ACSystem.Domain.Entity;
using ACSystem.Infrastructure.Const;
using ACSystem.Infrastructure.Exceptions;

namespace ACSystem.Application.Features.LetterReference.Handlers.Commands
{
    public class CreateLetterReferenceCommandHandler : IRequestHandler<CreateLetterReferenceCommand, BaseCommandResponse>
    {

        private readonly ILetterReferenceRepository _letterReferenceRepository;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;
        private readonly ILetterAttachRepository _letterAttachManager;

        public CreateLetterReferenceCommandHandler(ILetterReferenceRepository letterReferenceRepository,
                                 IMapper mapper, IFileManager fileManager, ILetterAttachRepository letterAttachManager)
        {
            _letterReferenceRepository = letterReferenceRepository;
            _mapper = mapper;
            _fileManager = fileManager;
            _letterAttachManager = letterAttachManager;
        }


        public async Task<BaseCommandResponse> Handle(CreateLetterReferenceCommand request, CancellationToken cancellationToken)
        {
            var response  = new BaseCommandResponse();

            try
            {
                var validator = new CreateLetterReferenceDtoValidator();

                var validationResult = await validator.ValidateAsync(request.CreateLetterReferenceDto);

                if (validationResult.IsValid == false)
                {
                    var Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    response.Failure(errors: Errors);
                }
                else
                {

                   var letterRef =   await _letterReferenceRepository.GetSingleAsync(a=>a.FromEmployeeId == request.CreateLetterReferenceDto.FromEmployeeId &&
                                                                     a.ToEmployeeId == request.CreateLetterReferenceDto.ToEmployeeId && 
                                                                     a.LetterId == request.CreateLetterReferenceDto.LetterId  , cancellationToken);


                    if (letterRef != null)
                        throw new AppException(DefaultConst.LetterRefExist);


                    var newLetterReference = new Domain.Entity.LetterReference
                    {
                        LetterId = request.CreateLetterReferenceDto.LetterId,
                        FromEmployeeId =  request.CreateLetterReferenceDto.FromEmployeeId,
                        ToEmployeeId = request.CreateLetterReferenceDto.ToEmployeeId,
                        ReplyText = request.CreateLetterReferenceDto.ReplyText,
                    };

                    await _letterReferenceRepository.Create(newLetterReference, cancellationToken);
                    await _letterReferenceRepository.SaveChanges(cancellationToken);

                    // save files
                    if (request.CreateLetterReferenceDto.File.Any())
                    {
                        var fileNames = await _fileManager.Save(request.CreateLetterReferenceDto.File,cancellationToken);
                        foreach (var filename in fileNames)
                        {
                            var newAttach = new LetterAttach(filename, newLetterReference.Id);
                            await _letterAttachManager.Create(newAttach, cancellationToken);
                            await _letterReferenceRepository.SaveChanges(cancellationToken);

                        }
                    }
                   


                    response.Success();


                }
            }
            catch (Exception)
            {
                //response.Failure(message: ex.Message.ToString());
                throw;
            }

            return response;
        }
    }
}
