using AutoMapper;
using Dziennik.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Mark.Queries.GetMark
{
    public class GetMarkQueryHandler : IRequestHandler<GetMarkQuery, IEnumerable<MarkDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMarkRepository _markRepository;

        public GetMarkQueryHandler(IMarkRepository markRepository, IMapper mapper)
        {
            _mapper=mapper;
            _markRepository = markRepository;
        }
        public async Task<IEnumerable<MarkDto>> Handle(GetMarkQuery request, CancellationToken cancellationToken)
        {
            var result =await  _markRepository.GetAllById(request.Id);

            var dtos= _mapper.Map<IEnumerable<MarkDto>>(result);

            return dtos;
        }
    }
}
