import ReactStars from "react-rating-stars-component";
import { IoIosStar, IoIosStarHalf, IoIosStarOutline } from "react-icons/io";

type PropsType = {
    edit: boolean;
    value: number;
};

const Stars = (props: PropsType) => (
    <ReactStars
        isHalf={true}
        size={24}
        emptyIcon={<IoIosStarOutline />}
        halfIcon={<IoIosStarHalf />}
        fullIcon={<IoIosStar />}
        activeColor="#e4911a"
        color="#cccccc"
        edit={props.edit}
        value={props.value}
    />
);

export default Stars;
