using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PelisApp.Infraestructure.Repositories;
using PelisApp.Domain.Entities;
using PelisApp.Domain.DTOS;
using PelisApp.Domain.DTOS.Response;
using PelisApp.Domain.DTOS.Request;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using PelisApp.Domain.Interfaces;
using AutoMapper;
using FluentValidation;

/*Nombre de la escuela: Universidad Tecnologica Metropolitana
Alumno: Paredes Ayala Guillermo Aldair
Asignatura: Aplicaciones Web para 14.0
Nombre de la Maestra: Martinez Dominguez Ruth
Cuatrimestre: 5
Grupo: B
Parcial: 1
*/

namespace PelisApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PelisController : ControllerBase
    {
    private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly ServicePelis _service;
        private readonly IValidator<RequestPelis> _createValidator;
        private readonly RepositoryPelis _repository;
        public PelisController(RepositoryPelis repository, 
        IHttpContextAccessor httpContext, 
        IMapper mapper, 
        ServicePelis service, 
        IValidator<RequestPelis> createValidator)
        {
            this._repository = repository;
            this._httpContext = httpContext;
            this._mapper = mapper;
            this._service = service;
            this._createValidator = createValidator;
        }

        //Retorna todos los pois
        //Ejemplo para Thunder client: https://localhost:5001/api/Poi/Todos
        [HttpGet]
        [Route("Todos")]
        public async  Task<IActionResult> TodosLosDatos()
        {
            var peliculas = await _repository.TodosLosDatos();
            //var Respuesta = Garbages.Select(g => CreateDtoFromObject(g));
            var Respuestapeliculas = _mapper.Map<IEnumerable<Pelicula>,IEnumerable<ResponsePelis>>(peliculas);
            return Ok(Respuestapeliculas);
        } 

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _repository.PorID(id);
            //entity.Status = false;
            var rows = _repository.Update(id, entity);
            return NoContent();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> PorID(int id)
        {
            var pelicula = await _repository.PorID(id);

            if(pelicula == null)
                return NotFound("El POI no fue encontrado");

            var respuesta = _mapper.Map<Pelicula, ResponsePelis>(pelicula);

            return Ok(respuesta);
        }

        [HttpPost]
        
        public async Task<IActionResult> create(RequestPelis pelicula)
        {
            var Val = await _createValidator.ValidateAsync(pelicula);
            

            //var Val = _service.ValidatedPOI(entity);

            if(!Val.IsValid)
                return UnprocessableEntity (Val.Errors.Select(d => $"{d.PropertyName} => Error: {d.ErrorMessage}"));

            var entity = _mapper.Map<RequestPelis, Pelicula>(pelicula);

            var id = await _repository.create(entity);
            
            if(id <= 0)
                return Conflict("El registro falló, inténtelo de nuevo.");

            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{host}/api/Eventos/{id}";
            return Created(urlResult, id);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update (int id,[FromBody]Pelicula pelicula)
        {
            if(id <= 0)
                return NotFound("No se encontró el registro");
            
            pelicula.ID = id;

            var Validated = _service.ValidacionActualizarPeli(pelicula);

            if(!Validated)
                UnprocessableEntity("No es posible actualizar la información.");
            
            var updated = await _repository.Update(id, pelicula);

            if(!updated)
                Conflict("Ocurrió un falló al intentar actualizar");
            
            return NoContent();
        }

        #region"Request"
        private Pelicula CreateObjectFromDto(RequestPelis dto)
        {
            var pelicula = new Pelicula {
                ID = 0,
                Titulo = string.Empty,
                Director = string.Empty,
                Genero = string.Empty,
                FechaPublicacion = string.Empty
            
            };
            return pelicula;
        }
        #endregion
    }
}