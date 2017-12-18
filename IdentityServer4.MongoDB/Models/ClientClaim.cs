namespace IdentityServer4.MongoDB.Models
{
    public class ClientClaim
    {
        public ClientClaim()
        {

        }
        public ClientClaim(string type, string value)
        {
            this.type = type;
            this.value = value;
        }

        public string type { get; set; }
        public string value { get; set; }
    }
}