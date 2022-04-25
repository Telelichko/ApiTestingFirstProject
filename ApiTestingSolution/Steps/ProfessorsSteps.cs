namespace Tests.Steps
{
    using ApiGateway.ApiClient;
    using ApiGateway.Models.Requests;
    using ApiGateway.Models.Responses;
    using ApiGateway.Services;

    public class ProfessorsSteps : BaseApiTests<ProfessorsService>
    {
        private ProfessorsService _service;

        public ProfessorsSteps(ProfessorsService service)
        {
            _service = service;
        }

        internal async Task<IApiResponse<ProfessorAddResponse>> AddProfessor(ProfessorAddRequest professor)
        {
            IApiResponse<ProfessorAddResponse> actualProfessorAddResponse =
                await _service.AddNewProfessor("api/professors/add", professor);

            return actualProfessorAddResponse;
        }

        public async Task<IEnumerable<ProfessorGetResponse>> GetProfessorsList()
        {
            var actualProfessorsList =
                (await _service.GetProfessorsList("api/professors/list")).ResponseObject;

            return actualProfessorsList;
        }
    }
}