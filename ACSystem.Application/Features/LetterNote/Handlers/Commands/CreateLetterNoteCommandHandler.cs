using ACSystem.Application.Contracts.Persistence;
using ACSystem.Application.Contracts.Service;
using ACSystem.Application.DTOs.Letter.Validator;
using ACSystem.Application.DTOs.Letter;
using ACSystem.Application.Features.LetterNote.Requests.Commands;
using ACSystem.Application.Responses;
using ACSystem.Infrastructure.Utilities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACSystem.Application.DTOs.LetterNote.Validator;
using ACSystem.Domain.Entity;
using ACSystem.Application.DTOs.LetterNote;

namespace ACSystem.Application.Features.LetterNote.Handlers.Commands
{
    public class CreateLetterNoteCommandHandler : IRequestHandler<CreateLetterNoteCommand, BaseCommandResponse>
    {
        private readonly ILetterNoteRepository _letterNoteRepository;
        private readonly IMapper _mapper;


        public CreateLetterNoteCommandHandler(ILetterNoteRepository letterNoteRepository,
                                                 IMapper mapper)
        {
            _letterNoteRepository = letterNoteRepository;
            _mapper = mapper;
            
        }


        public async Task<BaseCommandResponse> Handle(CreateLetterNoteCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                var validator = new CreateLetterNoteDtoValidator();

                var validationResult = await validator.ValidateAsync(request.CreateLetterNoteDto);

                if (validationResult.IsValid == false)
                {
                    var Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    response.Failure(errors: Errors);
                }
                else
                {
                    var letterNote = _mapper.Map<Domain.Entity.LetterNote>(request.CreateLetterNoteDto);
                    letterNote = await _letterNoteRepository.Create(letterNote, cancellationToken);
                    await _letterNoteRepository.SaveChanges(cancellationToken);

                    response.Success(data: _mapper.Map<GetLetterNoteDto>(letterNote));

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
