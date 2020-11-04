using Newtonsoft.Json;

namespace ModelsNew
{
	/// <summary>
	/// Send message response.
	/// </summary>
	internal class SendMessageResponse : ApiResponseBase
	{
		/// <summary>
		/// Unique id of the message.
		/// </summary>
		[JsonProperty("message_token")]
		public long MessageToken { get; set; }
	}
}