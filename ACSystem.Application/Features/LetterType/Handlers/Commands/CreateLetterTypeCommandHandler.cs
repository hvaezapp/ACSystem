using ACSystem.Application.Contracts.Persistence;
using ACSystem.Application.DTOs.LetterType;
using ACSystem.Application.DTOs.LetterType.Validator;
using ACSystem.Application.Features.LetterType.Requests.Commands;
using ACSystem.Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.Features.LetterType.Handlers.Commands
{
    public class CreateLetterTypeCommandHandler : IRequestHandler<CreateLetterTypeCommand, BaseCommandResponse>
    {
        private readonly ILetterTypeRepository _letterTypeRepository;
        private readonly IMapper _mapper;

        public CreateLetterTypeCommandHandler(ILetterTypeRepository letterTypeRepository,
            IMapper mapper)
        {
            _letterTypeRepository = letterTypeRepository;
            _mapper = mapper;
        }




        public async Task<BaseCommandResponse> Handle(CreateLetterTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

           

            try
            {
                var validator = new CreateLetterTypeDtoValidator();

                var validationResult = await validator.ValidateAsync(request.CreateLetterTypeDto);

                if (validationResult.IsValid == false)
                {
                    var Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    response.Failure(errors: Errors);
                }
                else
                {

                    var letterType = _mapper.Map<Domain.Entity.LetterType>(request.CreateLetterTypeDto);
                    letterType = await _letterTypeRepository.Create(letterType, cancellationToken);
                    await _letterTypeRepository.SaveChanges(cancellationToken);

                    response.Success(data: _mapper.Map<GetLetterTypeDto>(letterType));

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
