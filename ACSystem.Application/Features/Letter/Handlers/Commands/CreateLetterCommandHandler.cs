using ACSystem.Application.Contracts.Persistence;
using ACSystem.Application.Contracts.Service;
using ACSystem.Application.DTOs.Employee;
using ACSystem.Application.DTOs.Employee.Validator;
using ACSystem.Application.DTOs.Letter;
using ACSystem.Application.DTOs.Letter.Validator;
using ACSystem.Application.DTOs.LetterType;
using ACSystem.Application.DTOs.LetterType.Validator;
using ACSystem.Application.Features.Employee.Requests.Commands;
using ACSystem.Application.Features.Letter.Requests.Commands;
using ACSystem.Application.Features.LetterType.Requests.Commands;
using ACSystem.Application.Responses;
using ACSystem.Domain.Entity;
using ACSystem.Infrastructure.Utilities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.Features.Letter.Handlers.Commands
{
    public class CreateLetterCommandHandler : IRequestHandler<CreateLetterCommand, BaseCommandResponse>
    {
        private readonly ILetterRepository _letterRepository;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public CreateLetterCommandHandler(ILetterRepository letterRepository,
            IMapper mapper , IFileManager fileManager)
        {
            _letterRepository = letterRepository;
            _mapper = mapper;
            _fileManager = fileManager;
        }




        public async Task<BaseCommandResponse> Handle(CreateLetterCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

           

            try
            {
                var validator = new CreateLetterDtoValidator();

                var validationResult = await validator.ValidateAsync(request.CreateLetterDto);

                if (validationResult.IsValid == false)
                {
                    var Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    response.Failure(errors: Errors);
                }
                else
                {
                    // save the file

                    //string fileAttachUrl = await _fileManager.Save(request.CreateLetterDto.File);

                    var newLetter = new Domain.Entity.Letter()
                    {
                        Title = request.CreateLetterDto.Title,
                        Description = request.CreateLetterDto.Description,
                        LetterTypeId = request.CreateLetterDto.LetterTypeId,
                        EmployeeId = request.CreateLetterDto.EmployeeId,
                        Code = AppUtility.GenerateLetterCode(),
                        Status = Infrastructure.Enums.LetterStatus.Open
                    };



                    var letter = await _letterRepository.Create(newLetter, cancellationToken);
                    await _letterRepository.SaveChanges(cancellationToken);

                    response.Success(data: _mapper.Map<LetterDto>(letter));

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
