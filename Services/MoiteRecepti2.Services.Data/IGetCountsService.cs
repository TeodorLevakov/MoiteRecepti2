namespace MoiteRecepti2.Services.Data
{
    using MoiteRecepti2.Services.Data.DTOs;
    using MoiteRecepti2.Web.ViewModels.Home;

    public interface IGetCountsService
    {
        //IndexViewModel GetCounts();
        CountsDTO GetCounts();
    }
}
