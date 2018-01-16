using System;
using System.Collections.Generic;
using Business;
using Data.Domain;
using FacebookEvents.API.Models;
using Microsoft.AspNetCore.Mvc;


namespace FacebookEvents.API.Controllers
{
    [Route("v1/events")]
    public class EventsController : Controller
    {
        private readonly IEventRepository _repository;
        private readonly IUrlHelper _urlHelper;

        public EventsController(IEventRepository repository, IUrlHelper urlHelper)
        {
            _repository = repository;
            _urlHelper = urlHelper;
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            var _event = _repository.GetEventById(id);
            if (_event == null)
                return NotFound();
            return Ok(_event);
        }

     
        [HttpGet(Name = "GetEvents")]
        public IActionResult Get(PagingParams pagingParams)
        {
            var model = _repository.GetEvents(pagingParams);

            Response.Headers.Add("X-Pagination", model.GetHeader().ToJson());
            var outputModel = new EventOutputModel
            {
                Paging = model.GetHeader(),
                Links = GetLinks(model),
                Items = model.List
            };
            return Ok(outputModel);
        }

        private List<LinkInfo> GetLinks(PagedList<Event> list)
        {
            var links = new List<LinkInfo>();

            if (list.HasPreviousPage)
                links.Add(CreateLink("GetEvents", list.PreviousPageNumber,
                    list.PageSize, "previousPage", "GET"));

            links.Add(CreateLink("GetEvents", list.PageNumber,
                list.PageSize, "self", "GET"));

            if (list.HasNextPage)
                links.Add(CreateLink("GetEvents", list.NextPageNumber,
                    list.PageSize, "nextPage", "GET"));

            return links;
        }

        private LinkInfo CreateLink(
            string routeName, int pageNumber, int pageSize,
            string rel, string method)
        {
            return new LinkInfo
            {
                Href = _urlHelper.Link(routeName,
                    new {PageNumber = pageNumber, PageSize = pageSize}),
                Rel = rel,
                Method = method
            };
        }

        [HttpGet("{dateTime}")]
        public IEnumerable<Event> GetAllEventsUntill(Int64 dateTime)
        {
            return _repository.GetEventsUntill(new DateTime(dateTime));
        }
    }
}
