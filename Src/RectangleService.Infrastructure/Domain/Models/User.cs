using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleService.Infrastructure.Domain.Models
{
    public class User : IdentityUser
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the profile picture.
        /// </summary>
        /// <value>
        /// The profile picture.
        /// </value>
        /// <summary>
        /// Gets or sets a value indicating whether this instance is global admin.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is global admin; otherwise, <c>false</c>.
        /// </value>
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        //public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        /// <summary>
        /// Gets or sets the two factor provider.
        /// </summary>
        /// <value>
        /// The two factor provider.
        /// </value>
        //public string TwoFactorProvider { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has authenticator application setup.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has authenticator application setup; otherwise, <c>false</c>.
        /// </value>

        /// <summary>
        /// Gets or sets the idp tenant user.
        /// </summary>
        /// <value>
        /// The idp tenant user.
        /// </value>

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        //public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        /// <summary>
        /// Gets or sets the modified by.
        /// </summary>
        /// <value>
        /// The modified by.
        /// </value>
        //public string ModifiedBy { get; set; }
        /// <summary>
        /// Gets or sets the modified on.
        /// </summary>
        /// <value>
        /// The modified on.
        /// </value>
        //public DateTime? ModifiedOn { get; set; }

    }
}
