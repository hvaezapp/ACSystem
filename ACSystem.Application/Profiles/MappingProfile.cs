using ACSystem.Application.DTOs.Employee;
using ACSystem.Application.DTOs.Letter;
using ACSystem.Application.DTOs.Letter.Validator;
using ACSystem.Application.DTOs.LetterNote;
using ACSystem.Application.DTOs.LetterType;
using ACSystem.Domain.Entity;
using AutoMapper;

namespace ACSystem.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region LetterType Mapping

            CreateMap<LetterType, CreateLetterTypeDto>().ReverseMap();
            CreateMap<LetterType, GetLetterTypeDto>().ReverseMap();

            #endregion




            #region Employee Mapping

            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
            CreateMap<Employee, GetEmployeeDto>().ReverseMap();

            #endregion




            #region Letter Mapping

            CreateMap<Letter, CreateLetterDto>().ReverseMap();
            CreateMap<Letter, LetterDto>().ReverseMap();
            CreateMap<Letter, GetLetterDto>().ReverseMap();

            #endregion



            #region Letter Attach Mapping

            CreateMap<Letter, LetterDto>().ReverseMap();
            CreateMap<Letter, GetLetterDto>().ReverseMap();

            #endregion


            #region Letter Note Mapping

            CreateMap<LetterNote, GetLetterNoteDto>().ReverseMap();
            CreateMap<LetterNote, CreateLetterNoteDto>().ReverseMap();
           
            #endregion


        }
    }
}
