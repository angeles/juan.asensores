using Newtonsoft.Json;

namespace InsuranceSite.Models
{
	public class LoginData
	{
		[JsonProperty("username")]
		public string Username { get; set; }
	}
}