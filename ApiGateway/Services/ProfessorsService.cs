namespace ApiGateway.Services
{
    using ApiClient;
    using Models.Requests;
    using Models.Responses;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProfessorsService : BaseApiService
    {
        public ProfessorsService(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<IApiResponse<IEnumerable<ProfessorGetResponse>>> GetProfessorsList(string endpoint)
        {
            IApiResponse<IEnumerable<ProfessorGetResponse>> professorsList =
                await _apiClient.SendGetRequestAsync<IEnumerable<ProfessorGetResponse>>(endpoint);

            return professorsList;
        }

        public async Task<IApiResponse<ProfessorGetResponse>> GetProfessor(string endpoint)
        {
            IApiResponse<ProfessorGetResponse> professor =
                await _apiClient.SendGetRequestAsync<ProfessorGetResponse>(endpoint);

            return professor;
        }

        public async Task<IApiResponse<ProfessorAddResponse>> AddNewProfessor(string endpoint, ProfessorAddRequest professorAddRequest)
        {
            IApiResponse<ProfessorAddResponse> professorAddResponse =
                await _apiClient.SendPostRequestAsync<ProfessorAddResponse>(endpoint, professorAddRequest);

            return professorAddResponse;
        }

        public async Task<IApiResponse<ProfessorDeleteResponse>> DeleteProfessor(string endpoint)
        {
            IApiResponse<ProfessorDeleteResponse> professor =
                await _apiClient.SendDeleteRequestAsync<ProfessorDeleteResponse>(endpoint);

            return professor;
        }
    }
}