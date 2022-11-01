// namespace SharpTemplar.Test;

// public class BasicsTests
// {
//     [Fact]
//     public void is_inside_directly()
//     {
//         var monad = new ExposedMonad(Markup()
//             .body().Enter()
//                 .a().Enter());

//         Assert.True(monad.isInside("a"));
//     }

//     [Fact]
//     public void is_inside_nested()
//     {
//         var monad = new ExposedMonad(Markup()
//             .body().Enter()
//                 .div().Enter()
//                     .a().Enter());

//         Assert.True(monad.isInside("div"));
//     }

//     [Fact]
//     public void is_inside_directly_false()
//     {
//         var monad = new ExposedMonad(Markup()
//             .body().Enter()
//                 .a().Enter());

//         Assert.False(monad.isInside("span"));
//     }

//     [Fact]
//     public void is_inside_nested_false()
//     {
//         var monad = new ExposedMonad(Markup()
//             .body().Enter()
//                 .div().Enter()
//                     .a().Enter());

//         Assert.False(monad.isInside("span"));
//     }

//     [Fact]
//     public void is_inside_wrong_branch()
//     {
//         var monad = new ExposedMonad(Markup()
//             .body().Enter()
//                 .div().Enter()
//                     .span().Exit()
//                 .a().Enter());

//         Assert.False(monad.isInside("span"));
//     }

//     [Fact]
//     public void ids_are_unique()
//     {
//         Assert.Equal(
//             Markup().body().@id("hello").Enter().a().@id("hello").Build(),
//             "Id 'hello' is already in use!"
//         );
//     }
// }