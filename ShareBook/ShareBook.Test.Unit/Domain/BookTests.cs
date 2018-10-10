using System;
using ShareBook.Domain;
using ShareBook.Domain.Enums;
using System.Collections.Generic;
using Xunit;

namespace ShareBook.Test.Unit.Domain
{
    public class BookTests
    {
        [Fact]
        public void BookStatusUnknow()
        {
            var book = new Book();
            Assert.Equal(BookStatus.Unknow, book.Status());
        }

        [Fact]
        public void BookStatusWaitingApproval()
        {
            var book = new Book{
                BookUsers = new List<BookUser>()
            };

            Assert.Equal(BookStatus.WaitingApproval, book.Status());
        }

        [Fact]
        public void BookStatusAvailable()
        {
            var book = new Book{
                BookUsers = new List<BookUser>(),
                Approved = true
            };

            Assert.Equal(BookStatus.Available, book.Status());
        }

        [Fact]
        public void BookStatusInvisible()
        {
            var bookUsers = new List<BookUser>();
            bookUsers.Add(new BookUser());

            var book = new Book{
                BookUsers = bookUsers
            };

            Assert.Equal(BookStatus.Invisible, book.Status());
        }

        [Fact]
        public void BookStatusDonated()
        {
            var bookUsers = new List<BookUser>();
            var bookUser = new BookUser();
            bookUser.UpdateBookUser(DonationStatus.Donated, null);

            bookUsers.Add(bookUser);
            
            var book = new Book{
                BookUsers = bookUsers
            };

            Assert.Equal(BookStatus.Donated, book.Status());
        }

        [Fact]
        public void TotalInteresedShouldBeZeroIfBookUsersIsNull()
        {
            var book = new Book();
            Assert.Equal(0, book.TotalInterested());
        }

        [Fact]
        public void TotalInteresedShouldBeEqualsTheBookUsersLength()
        {
            var bookUsers = new List<BookUser>();
            bookUsers.Add(new BookUser());
            bookUsers.Add(new BookUser());

            var book = new Book{
                BookUsers = bookUsers
            };

            Assert.Equal(2, book.TotalInterested());
        }

        [Fact]
        public void DaysInShowCaseShouldBeTheDifferenceBetweenTodayAndTheCreationDate()
        {
            int expectedDays = 5;
            var book = new Book{
                CreationDate = DateTime.Now.AddDays(expectedDays * -1)
            };

            Assert.Equal(expectedDays, book.DaysInShowcase());
        }
    }
}