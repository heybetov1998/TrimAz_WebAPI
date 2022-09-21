import CardFrame from "../CardFrame";
import Comment from "./Comment";

const user = {
    id: "u1",
    name: "Adil",
    givenRating: 3.2,
    comment: "Tets comesdf",
};

const Comments = () => (
    <CardFrame>
        <ul className="comments">
            <Comment user={user} />
            <Comment user={user} />
        </ul>
    </CardFrame>
);

export default Comments;
