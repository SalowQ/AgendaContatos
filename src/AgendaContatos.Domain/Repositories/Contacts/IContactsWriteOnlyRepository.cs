using AgendaContatos.Domain.Entities;

namespace AgendaContatos.Domain.Repositories.Contacts
{
    public interface IContactsWriteOnlyRepository
    {
        Task Add(Contact contact);
        /// <summary>
        /// Essa função retorna TRUE se o contato foi deletado com sucesso, ou FALSE se não foi encontrado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(long id);
    }
}
