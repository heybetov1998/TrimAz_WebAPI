import CardFrame from "../UI/CardFrame";
import Stars from "../UI/Stars";

type PropsType = {
    barber: {
        name: string;
        image?: {
            src?: any;
            alt?: string;
        };
        link?: string;
        rating: number;
    };
};

const BarberCard = (props: PropsType) => {
    return (
        <CardFrame className="barber_card d-flex">
            <div className="profile_image">
                <img
                    src={
                        props.barber.image?.src ??
                        require("../../assets/images/profile-picture.png")
                    }
                    alt={props.barber.image?.alt ?? "Barber profile picture"}
                />
            </div>
            <div className="info">
                <div className="name">{props.barber.name}</div>
                <Stars edit={false} value={props.barber.rating} />
            </div>
        </CardFrame>
    );
};

export default BarberCard;
