// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using UnikProjekt.Web.Data;
using UnikProjekt.Web.Models;
using UnikProjekt.Web.Models.DTOs;
using UnikProjekt.Web.ProxyServices;
using UnikProjekt.Web.Services;

namespace UnikProjekt.Web.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IUserServiceProxy _userServiceProxy;
        private readonly UserClaimsService _userClaimsService;
        private readonly RoleManager<IdentityRole> _roleManager;


        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            IUserServiceProxy userServiceProxy,
            UserClaimsService userClaimsService)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _userServiceProxy = userServiceProxy;
            _userClaimsService = userClaimsService;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string? Role { get; set; }

            [Required]
            [Display(Name = "Adresse")]
            public string Address { get; set; }

            //[ValidateNever]
            //public IEnumerable<SelectListItem> RoleList { get; set; }

            //[ValidateNever]
            //public IEnumerable<SelectListItem> RoleList { get; set; }

            public Guid Id { get; set; }

            [Required]
            [Display(Name = "Fornavn")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Efternavn")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Mobilnummer")]
            public string MobileNumber { get; set; }

            [Required]
            [Display(Name = "Gadenavn")]
            public string Street { get; set; }

            [Required]
            [Display(Name = "Husnummer")]
            public string StreetNumber { get; set; }

            [Required]
            [Display(Name = "Postnummer")]
            public string PostCode { get; set; }

            [Required]
            [Display(Name = "By")]
            public string City { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                //var user = CreateUser();

                var user = new ApplicationUser
                {
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    UserName = Input.Email,
                    Email = Input.Email,
                    MobileNumber = Input.MobileNumber,
                    Street = Input.Street,
                    StreetNumber = Input.StreetNumber,
                    PostCode = Input.PostCode,
                    City = Input.City
                    //TODO: ANH: Add List of roles and Start/end Dates
                };

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //The user gets a role based on the input
                    await _userManager.AddToRoleAsync(user, Input.Role);


                    //If the role exist in our ClaimsTypes, add the role
                    if (ClaimsTypes.UserTypeList.Equals(Input.Role))
                    {
                        await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, Input.Role));
                    }
                    else
                    {
                        _logger.LogWarning($"Role {Input.Role} is not recognized.");
                    }

                    // Gets the user Id of the newly created Identity
                    var userId = await _userManager.GetUserIdAsync(user);
                    //D betyder Guid formatere til 32 digits med bindestreng
                    var userIdGuid = Guid.ParseExact(userId, "D");

                    var createUserDto = new CreateUserDto
                    {
                        Id = userIdGuid,
                        FirstName = Input.FirstName,
                        LastName = Input.LastName,
                        Email = Input.Email,
                        MobileNumber = Input.MobileNumber,
                        Street = Input.Street,
                        StreetNumber = Input.StreetNumber,
                        PostCode = Input.PostCode,
                        City = Input.City
                    };


                    // Map til CreateUserDto hvor userId (identity userId) sættes som Id
                    //Calling our API through UserServiceProxy - sending createUserDto to our API
                    await _userServiceProxy.CreateUserAsync(createUserDto);

                    //TODO: ANH: Tjek om det var en succes, hvis ja, opret så UserRole med UserId og RoleId
                    // roller er fx beboer, formand osv. 
                    //await _userServiceProxy.CreateUserRoleAsync();

                    //TODO:ANH: UserRoleReturneres of er succes? Hvis ja, så asign claim ud fra det?

                    //Adding claims based on the users role
                    await _userClaimsService.AssignClaimsAsync(user, Input.Role, isNewUser: true);





                    //var response = await _userServiceProxy.PostAsJsonAsync("http://localhost:5062/api/account", createUserDto);
                    //if (response.IsSuccessStatusCode is false)
                    //{
                    //    throw new Exception("Failed to post user");
                    //}


                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new
                        {
                            email = Input.Email,
                            returnUrl = returnUrl
                        });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
