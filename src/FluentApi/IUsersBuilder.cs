using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApi
{
    public interface IUsersBuilder
    {
        ICredentialBuilder AddLogin();

        IGroupBuilder AddGroups();
    }

    public interface ICredentialBuilder : IUsersBuilder
    {
        IRoleBuilder WithCredential(
            string username = "",
            string password = ""
            );
    }

    public interface IUserBuilder : IGroupBuilder
    {
        ICredentialBuilder AddUser();
    }

    public interface IGroupBuilder : IUsersBuilder
    {
        IUserBuilder AddGroup(
            string name = "");
    }

    public interface IRoleBuilder : IGroupBuilder
    {
        IRightBuilder AndRole(
            string database = ""
            );
    }

    public interface IRightBuilder : IRoleBuilder
    {
        IRightBuilder AddRight(
            string permission = ""
            );
    }
}
