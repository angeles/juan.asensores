namespace ApiServer.Repository
{
	public interface IUnitOfWork
	{
		void Confirm();

		void Revert();
	}
}
