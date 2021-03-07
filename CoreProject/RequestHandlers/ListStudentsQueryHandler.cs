using MediatR;
using SharedProject.Models;
using SharedProject.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreProject.RequestHandlers
{
    public class ListStudentsQueryHandler : IRequestHandler<ListStudentsQuery, IEnumerable<Student>>
    {

        public async Task<IEnumerable<Student>> Handle(ListStudentsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new List<Student> { new Student { Id = 1, Name = "Joao" } });
        }
    } 
}
