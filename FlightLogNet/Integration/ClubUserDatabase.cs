namespace FlightLogNet.Integration
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Models;

    using Microsoft.Extensions.Configuration;
    using RestSharp;

    public class ClubUserDatabase(IConfiguration configuration, IMapper mapper) : IClubUserDatabase
    {
        private readonly RestClient _client = new RestClient(configuration["ClubUsersApi"]);
        private readonly RestRequest _request = new RestRequest("club/user");

        public bool TryGetClubUser(long memberId, out PersonModel personModel)
        {
            personModel = this.GetClubUsers().FirstOrDefault(person => person.MemberId == memberId);

            return personModel != null;
        }

        public IList<PersonModel> GetClubUsers()
        {
            IList<ClubUser> x = this.ReceiveClubUsers();
            return this.TransformToPersonModel(x);
        }

        private List<ClubUser> ReceiveClubUsers()
        {
            var response = _client.Get<List<ClubUser>>(_request);
            return response;
        }

        private List<PersonModel> TransformToPersonModel(IList<ClubUser> users)
        {
            return mapper.ProjectTo<PersonModel>(users.AsQueryable()).ToList();
        }
    }
}
