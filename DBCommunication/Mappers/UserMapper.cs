using DBCommunication.Models.Account;
using DBCommunication.Models.User;
using DBCommunication.Dtos.User;
using DBCommunication.Identity;

namespace DBCommunication.Mappers
{
    public static class UserMapper
    {

        public static UserDto ApplicationUserToUserDto(
            ApplicationUser appUser,
            string role)
        {
            var result = new UserDto
            {
                UserId = appUser.Id,
                UserName = appUser.UserName,
                Email = appUser.Email,
                Role = role
            };

            return result;
        }

        public static void UserUpdateDtoToApplicationUser(
            UserUpdateDto userUpdate,
            ApplicationUser appUser)
        {
            appUser.UserName = userUpdate.UserName;
            appUser.Email = userUpdate.Email;
        }

        public static UserCreateDto UserCreateModelToUserCreateDto(UserCreateModel userCreate)
        {
            var userCreateDto = new UserCreateDto
            {
                UserName = userCreate.UserName,
                Password = userCreate.Password,
                Email = userCreate.Email,
                Role = userCreate.Role
            };

            return userCreateDto;
        }

        public static ApplicationUser UserCreateDtoToApplicationUser(UserCreateDto userCreate)
        {
            var result = new ApplicationUser
            {
                UserName = userCreate.UserName,
                Email = userCreate.Email
            };

            return result;
        }

        public static UserCreateDto SignUpUserModelToUserCreateDto(SignUpUserModel userCreate)
        {
            var userCreateDto = new UserCreateDto
            {
                UserName = userCreate.UserName,
                Password = userCreate.Password,
                Email = userCreate.Email,
                Role = userCreate.Role
            };

            return userCreateDto;
        }

        public static UserUpdateDto UserUpdateModelToUserUpdateDto(UserUpdateModel userUpdate)
        {
            var userUpdateDto = new UserUpdateDto
            {
                UserName = userUpdate.UserName,
                Password = userUpdate.Password,
                Email = userUpdate.Email
            };

            return userUpdateDto;
        }

        public static UserProfileUpdateDto UserProfileUpdateModelToUserProfileUpdateDto(UserProfileUpdateModel userProfileUpdate)
        {
            var userProfileUpdateDto = new UserProfileUpdateDto
            {
                UserName = userProfileUpdate.UserName,
                Email = userProfileUpdate.Email,
                Role = userProfileUpdate.Role
            };

            return userProfileUpdateDto;
        }

        public static UserUpdatePasswordDto UserUpdatePasswordModelToUserUpdatePasswordDto(UserUpdatePasswordModel userUpdatePassword)
        {
            var userUpdatePasswordDto = new UserUpdatePasswordDto
            {
                CurrentPassword = userUpdatePassword.CurrentPassword,
                NewPassword = userUpdatePassword.NewPassword
            };

            return userUpdatePasswordDto;
        }

        public static void UserProfileUpdateDtoToApplicationUser(
            UserProfileUpdateDto userProfileUpdate,
            ApplicationUser appUser)
        {
            appUser.UserName = userProfileUpdate.UserName;
            appUser.Email = userProfileUpdate.Email;
        }
    }
}
