using BookService.BookSystem;

namespace BookService.Predicate
{
    interface IPredicate
    {
        bool IsMatch(Book book);
    }
}
