function solve(){

    class Post {
        constructor(title, content){
            this.title = title;
            this.content = content;
        }

        toString(){
            return [
                `Post: ${this.title}`,
                `Content: ${this.content}`
            ].join("\n");
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes){
            super(title, content);

            this.likes = Number(likes);
            this.dislikes = Number(dislikes);
            this.comments = [];
        }

        addComment(comment){
            this.comments.push(comment);
        }

        toString(){
            let result = [];
            if (comments.length === 0) {
                result = [
                    super.toString(),
                    `Rating: ${this.likes - this.dislikes}`
                ].join("\n");
            }
            else{
                result [
                    super.toString(),
                    `Rating: ${this.likes - this.dislikes}`,
                    "Comments:",
                    this.comments.forEach(c => result.push(` * ${c}`))
                ].join("\n");
            }
            
            return result;
        }
    }

    class BlogPost extends Post{
        constructor(title, content, views){
            super(title, content);

            this.views = Number(views);
            this.comments = [];
        }

        view(){
            this.views++;
            return this;
        }

        toString(){
            return [
                super.toString(),
                `Views: ${this.views}`
            ].join("\n");
        }
    }

    return{
        Post,
        SocialMediaPost,
        BlogPost
    }
}

let posts = solve();
