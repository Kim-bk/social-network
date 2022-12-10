using SocialNetwork.Models.DAL;
using SocialNetwork.Services.Interfaces;

namespace SocialNetwork.Services.Base
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapperCustom _mapper;
        public BaseService(IUnitOfWork unitOfWork, IMapperCustom mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
