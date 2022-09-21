import SubmitButton from "../UI/Buttons/SubmitButton";
import CardFrame from "../UI/CardFrame";
import SquareImage from "../UI/Images/SquareImage";
import Stars from "../UI/Stars";

const BarberInfo = () => (
    <CardFrame className="barber_info">
        <SquareImage
            img={{ src: require("../../assets/images/profile-picture.png") }}
        />
        <div>
            <div>
                <h2 className="name">Barber Name</h2>
                <div className="star_holder d-flex justify-content-center">
                    <Stars edit={false} value={2.3} />
                </div>
            </div>
            <div>
                <SubmitButton className="mt-3" text="Reserve" type="button" />
            </div>
        </div>
    </CardFrame>
);

export default BarberInfo;
