function solve(){
    class Post{
        constructor(title, content){
            this.title = title,
            this.content = content
        }

        toString() {
            let result = [`Post: ${this.title}`, `Content: ${this.content}`];
            return result.join("\n");
        }
    }

    class SocialMediaPost extends Post{
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
            let result = [
                `Post: ${this.title}`,
                `Content: ${this.content}`,
                `Rating: ${this.likes - this.dislikes}`
            ]

            if(this.comments.length > 0){
                result.push("Comments:");

                this.comments.forEach(element => {
                   result.push(` * ${element}`);
                });
            }

            return result.join("\n");
        }
    }

    class BlogPost extends Post{
        constructor(title, content, views){
            super(title, content);
            this.views = Number(views);
        }

        view() {
            this.views++;
            return this;
        }

        toString(){
            let result = [
                `Post: ${this.title}`,
                `Content: ${this.content}`,
                `Views: ${this.views}`,               
            ];

            return result.join("\n");
        }
    }

    return {Post, SocialMediaPost, BlogPost }
}


const posts = solve();

const a = new posts.Post("First Post", "Lorem Ipsum Dolor Sit Amet", 10, 5);
a.addComment("I commented");
a.addComment("I agree");

console.log(a);

