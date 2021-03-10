using FluentValidation;
using SharedProject.Queries;

namespace CoreProject.Validations
{
    public class ListStudentsQueryValidator : AbstractValidator<ListStudentsQuery>
    {
        public ListStudentsQueryValidator()
        {
        }
    }
}