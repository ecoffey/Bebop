namespace Bebop
{
	public interface IMapResourceTo<TResource> where TResource : IResource
	{
		BebopRoute<TResource> To(string url);
	}
}