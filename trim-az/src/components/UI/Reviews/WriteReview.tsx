import SubmitButton from "../Buttons/SubmitButton";
import CardFrame from "../CardFrame";
import Stars from "../Stars";

const WriteReview = () => (
    <CardFrame title="Write a review" className="write_review">
        <form action="">
            <p className="rate_name">Rate:</p>
            <Stars edit={true} value={0} />
            <textarea
                className="userComment mb-3"
                placeholder="Write your comment"
                id="userComment"
            ></textarea>
            <SubmitButton text="Submit"/>
        </form>
    </CardFrame>
);

export default WriteReview;
