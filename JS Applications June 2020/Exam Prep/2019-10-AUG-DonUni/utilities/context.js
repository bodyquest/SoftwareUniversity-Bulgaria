export default function (context){
    firebase.auth().onAuthStateChanged(function(user) {
        if (user) {
          // User is signed in.
          context.isLoggedIn = true;
          context.username = user.email;
          context.userId = user.uid;
          localStorage.setItem("userId", user.uid);

          var displayName = user.displayName;
          var emailVerified = user.emailVerified;
          var photoURL = user.photoURL;
          var isAnonymous = user.isAnonymous;
          var providerData = user.providerData;
          // ...
        } else {
          // User is signed out.
          context.isLoggedIn = false;
          context.username = null;
          context.userId = null;
          localStorage.removeItem("userId", user.uid);
          // ...
        }
      });

      context.loadPartials({
          header: "../views/shared/header.hbs",
          footer: "../views/shared/footer.hbs"
        });
  }