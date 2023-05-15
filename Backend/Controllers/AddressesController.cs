﻿using Backend.Models.Entities.User;
using Backend.Models.Users;
using Backend.Repositories.Users;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AddressService _addressService;
        private readonly UserService _userService;


        public AddressesController(AddressService addressService, UserService userService)
        {
            _addressService = addressService;
            _userService = userService;
        }

        [HttpPost("register")]
        [Authorize]
        public async Task<IActionResult> RegisterAddress(AddressRegisterModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userService.GetUserFromToken(User);

                if (await _addressService.RegisterAddressAsync(user, model))
                {
                    return Ok("Address registered successfully");
                }
                else
                {
                    return BadRequest("Failed to register address");
                }

            }
            return BadRequest("Invalid address data");
        }
    }
}