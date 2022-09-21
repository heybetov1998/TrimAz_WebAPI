import { Link } from "react-router-dom";
import Stars from "../Stars";

type PropsType = {
    user: {
        id: string | number;
        name: string;
        givenRating: number;
        image?: {
            src: string;
            alt?: string;
        };
        comment: string;
    };
};

const Comment = (props: PropsType) => (
    <li className="comment">
        <div className="comment_author d-flex">
            <Link className="profile_image" to={`/users/${props.user.id}`}>
                <img
                    src={
                        props.user.image
                            ? require(props.user.image.src)
                            : require("../../../assets/images/profile-picture.png")
                    }
                    alt={props.user.image?.alt ?? "Profile image"}
                />
            </Link>
            <div className="info">
                <Link className="name" to={`/users/${props.user.id}`}>{props.user.name}</Link>
                <p className="date">19.09.2022</p>
                <Stars edit={false} value={props.user.givenRating} />
            </div>
        </div>
        <div className="comment_text">{props.user.comment}</div>
    </li>
);

export default Comment;
