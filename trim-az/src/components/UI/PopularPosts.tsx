import { Link } from "react-router-dom";
import CardFrame from "./CardFrame";
import Column from "./grid/Column";
import Row from "./grid/Row";

type PropsType = {
    posts: {
        id: string | number;
        title: string;
        createdDate: string;
        image: {
            src: string;
            alt: string;
        };
    }[];
};

const PopularPosts = (props: PropsType) => {
    return (
        <CardFrame className="popular_posts" title="Popular blogs">
            {props.posts.map((post) => (
                <Row key={post.id} className="post_item mb-3">
                    <Column default={4} sm={4} md={4} lg={4} xl={4}>
                        <Link className="post_image" to={"#"}>
                            <img src={post.image.src} alt={post.image.alt} />
                        </Link>
                    </Column>
                    <Column default={8} sm={8} md={8} lg={8} xl={8}>
                        <Link to={"#"} className="post_title">
                            {post.title}
                        </Link>
                        <p>{post.createdDate}</p>
                    </Column>
                </Row>
            ))}
        </CardFrame>
    );
};

export default PopularPosts;
