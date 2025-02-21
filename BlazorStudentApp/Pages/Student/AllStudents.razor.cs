using BlazorStudentApp.Data.Services;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

namespace BlazorStudentApp.Pages.Student
{
    public partial class AllStudents
    {

        [Inject]
        public required IStudentsService StudentsService { get; set; }
        [Inject]
        public IJSRuntime? JsRuntime { get; set; }
        [Inject]
        public NavigationManager? _navManager { get; set; }

        public List<Data.Models.Student>? students;
        private Data.Models.Student? selectedStudent;
        bool showModal = false;

        protected override async Task OnInitializedAsync()
        {
            students = await StudentsService.GetStudentsAsync();
        }

        protected void DeleteStudentConfirmation(Data.Models.Student student)
        {
            selectedStudent = student;
            showModal = true;
        }

        protected void EditStudentConfirmationRedirect(Data.Models.Student student)
        {
            _navManager?.NavigateTo("/edit/" + student.Id, true);
        }



        void CancelDelete() => showModal = false;
        async Task ConfirmDelete()
        {
            await StudentsService.DeleteStudentAsync(selectedStudent.Id);
            students = await StudentsService.GetStudentsAsync();
            showModal = false;
        }

    }
}
