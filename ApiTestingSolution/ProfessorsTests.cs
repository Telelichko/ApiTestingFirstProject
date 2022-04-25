namespace Tests
{
    using ApiGateway.ApiClient;
    using ApiGateway.Models.Requests;
    using ApiGateway.Models.Responses;
    using ApiGateway.Services;
    using FluentAssertions;
    using FluentAssertions.Execution;
    using NUnit.Framework;
    using Steps;
    using System;
    using System.Threading.Tasks;

    [TestFixture]
    public class ProfessorsTests : BaseApiTests<ProfessorsService>
    {
        private readonly ProfessorsSteps _professorsSteps;

        public ProfessorsTests()
        {
            _professorsSteps = new ProfessorsSteps(_service);
        }

        [Test]
        public async Task UserCanGetProfessorsList()
        {
            var actualProfessorsList = await _professorsSteps.GetProfessorsList();

            using (new AssertionScope())
            {
                actualProfessorsList.Should().HaveCountGreaterOrEqualTo(2);
            }
        }

        [Test]
        public async Task UserCanGetProfessorByGuid()
        {
            var id = "d8029f27-e4cd-4b18-a22e-c97bb2a66a03";
            ProfessorGetResponse expectedProfessor =
                new ProfessorGetResponse()
                {
                    Id = new Guid(id),
                    FirstName = "John",
                    LastName = "Braun",
                };

            var actualProfessor =
                (await _service.GetProfessor($"api/professors/{id}")).ResponseObject;

            actualProfessor.Should().BeEquivalentTo(expectedProfessor);
        }

        [Test]
        public async Task UserCanAddProfessor()
        {
            ProfessorAddRequest professor = new ProfessorAddRequest()
            {
                FirstName = "Den",
                LastName = "Smith"
            };

            IApiResponse<ProfessorAddResponse> actualProfessorAddResponse = await _professorsSteps.AddProfessor(professor);

            var guid = actualProfessorAddResponse.ResponseObject.CreatedId;

            using (new AssertionScope())
            {
                actualProfessorAddResponse.ResponseStatus.Equals(200);
                guid.Should().NotBeEmpty();
                actualProfessorAddResponse.ResponseObject.Message.Should().NotBeEmpty();
            }

            var actualGetProfessorResponse =
                await _service.GetProfessor($"api/professors/{guid}");

            actualGetProfessorResponse.ResponseStatus.Equals(200);
        }

        [Test]
        public async Task UserCanDeleteProfessor()
        {
            ProfessorAddRequest professor = new ProfessorAddRequest()
            {
                FirstName = "Den",
                LastName = "Smith"
            };

            IApiResponse<ProfessorAddResponse> actualProfessorAddResponse = await _professorsSteps.AddProfessor(professor);

            var guid = actualProfessorAddResponse.ResponseObject.CreatedId;

            var actualDeleteProfessorResponse = await _service.DeleteProfessor($"api/professors/{guid}");

            var actualGetProfessorResponse =
                await _service.GetProfessor($"api/professors/{guid}");

            using (new AssertionScope())
            {
                actualDeleteProfessorResponse.ResponseStatus.Equals(200);
                actualGetProfessorResponse.ResponseStatus.Equals(404);
            }
        }

        [Test]
        [TestCase(null, "Smith", "Used without first name is created.")]
        [TestCase("Den", null, "Used without last name is created.")]
        public async Task UserAddProfessorNegative(string firstName, string lastName, string expectedErrorMessage)
        {
            ProfessorAddRequest professor = new ProfessorAddRequest()
            {
                FirstName = firstName,
                LastName = lastName
            };

            IApiResponse<ProfessorAddResponse> actualProfessorAddResponse = await _professorsSteps.AddProfessor(professor);

            actualProfessorAddResponse.ResponseStatus.Equals(400);
        }
    }
}