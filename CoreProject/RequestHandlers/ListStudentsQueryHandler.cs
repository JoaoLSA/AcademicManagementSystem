using CoreProject.Models;
using CoreProject.Repositories;
using MediatR;
using SharedProject.Queries;
using SharedProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreProject.RequestHandlers
{
    public class ListStudentsQueryHandler : IRequestHandler<ListStudentsQuery, IEnumerable<StudentViewModel>>
    {
        private readonly IRepository<Student> _studentRepository;

        public ListStudentsQueryHandler(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentViewModel>> Handle(ListStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = _studentRepository.GetAll();
            Console.WriteLine(students);
            return await _studentRepository.GetAllProjectedAsync<StudentViewModel>();
        }
    } 
}
