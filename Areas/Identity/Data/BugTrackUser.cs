using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BugTrack.Areas.Identity.Data;

// Add profile data for application users by adding properties to the BugTrackUser class
public class BugTrackUser : IdentityUser
{
    public string UserFirstname { get; set; }
    public string UserLastname { get; set; }
}

