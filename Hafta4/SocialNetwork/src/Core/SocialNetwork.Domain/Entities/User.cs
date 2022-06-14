using Microsoft.AspNetCore.Identity;
using SocialNetwork.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities
{
    public class User : IdentityUser, IBaseEntity
	{
		[Key]
		public string Id { get; set; } = Guid.NewGuid().ToString();
		[Required]
		public string Name { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string Email { get; set; }
	}
}
