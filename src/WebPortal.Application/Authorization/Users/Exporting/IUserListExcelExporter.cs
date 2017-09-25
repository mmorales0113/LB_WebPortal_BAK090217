using System.Collections.Generic;
using WebPortal.Authorization.Users.Dto;
using WebPortal.Dto;

namespace WebPortal.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}