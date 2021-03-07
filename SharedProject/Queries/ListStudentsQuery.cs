using MediatR;
using SharedProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject.Queries
{
    public class ListStudentsQuery : IRequest<IEnumerable<Student>>
    {
    }
}
