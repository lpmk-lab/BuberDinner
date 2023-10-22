

using ErrorOr;

namespace SmartRMS.Domain.Common.Errors;

    public static partial class CommonErrors
{
    public static class Delete
    {
        public static Error RecordNotFound => Error.NotFound
            (
            code: "Record.NotFound",
            description: "Record not Found"
            );
    }
}

