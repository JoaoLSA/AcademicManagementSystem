using MediatR;
using SharedProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject.Queries
{
    public class ListStudentsQuery : IRequest<IEnumerable<StudentViewModel>>
    {
    }
}
