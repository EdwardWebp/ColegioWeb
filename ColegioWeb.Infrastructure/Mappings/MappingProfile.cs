using AutoMapper;
using ColegioWeb.Core.DTO.Asignatura;
using ColegioWeb.Core.DTO.Asistencia;
using ColegioWeb.Core.DTO.Calificaciones;
using ColegioWeb.Core.DTO.Estudiantes;
using ColegioWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColegioWeb.Infrastructure.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile() {
			CreateMap<Asignatura, AsignaturaDTO>().ReverseMap();
			CreateMap<CAsignaturaDTO, Asignatura>();

			CreateMap<Asistencia, AsistenciaDTO>().
			ForMember(d => d.NombreEstudiante, o => o.MapFrom(c => c.estudiantesnav.Nombre)).
			ForMember(d => d.NombreAsignatura, o => o.MapFrom(a => a.asignaturanav.Nombre)).ReverseMap();
			CreateMap<CAsistenciaDTO, Asistencia>();
			CreateMap<Asistencia, AsistenciaResponDTO>();

			CreateMap<Estudiantes, EstudianteDTO>().ReverseMap();
			CreateMap<CEstudiantesDTO, Estudiantes>();

			CreateMap<Calificaciones, CalificacionesDTO>().
			ForMember(d => d.NombreEstudiante, o => o.MapFrom(c => c.estudiantesnav.Nombre)).
			ForMember(d => d.NombreAsignatura, o => o.MapFrom(c => c.asignaturanav.Nombre)).ReverseMap();
			CreateMap<CCalificacionesDTO, Calificaciones>();
			CreateMap<Calificaciones, CalificacionesResponDTO>();
		}
	}
}
