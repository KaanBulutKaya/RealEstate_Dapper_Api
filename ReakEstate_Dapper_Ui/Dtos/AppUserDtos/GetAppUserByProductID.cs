﻿namespace ReakEstate_Dapper_Ui.Dtos.AppUserDtos
{
    public class GetAppUserByProductID
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserImageUrl { get; set; }
    }
}
