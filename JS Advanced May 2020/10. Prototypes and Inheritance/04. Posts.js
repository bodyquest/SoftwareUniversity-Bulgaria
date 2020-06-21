function solve() {

    class Post {
        constructor(title, content){
            this.title = title;
            this.content = content;
        }


        toString(){
            return [
                `Post: ${this.title}`,
                `Content: ${this.content}`
            ].join("\n")
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, comment, likes, dislikes){
            super(title, comment);
            

            this.comments = [];
        }

        addComment(comment){
            this.comments.push(comment);
        }

        toString(){
            const result = [
                super.toString(),
                `Rating: ${this.likes - this.dislikes}`

            ];

            if (this.comments.length > 0) {
                result.push("Comments:");
                this.comments.forEach(c => result.push(` * ${c}`));
            }

            return result.join("\n");
        }
    }

    class BlogPost extends Post {
        constructor(title, comment, views){
            super(title, comment);

            this.views = views;
        }

        view(){
            this.views++;
            return this;
        }

        toString(){
            result = [
                super.toString(),
                `Views: ${this.views}`
            ].join("\n");

            return result;
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost
    }
}

const posts = solve();

const a = new posts.Post("First Post", "Lorem Ipsum Dolor Sit Amet", 10, 5);
a.addComment("I commented");
a.addComment("I agree");

console.log(a);

