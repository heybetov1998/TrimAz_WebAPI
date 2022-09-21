import SwiperNext from "./SwiperNext";
import SwiperPrev from "./SwiperPrev";

interface Props {
    id: string;
}

const NavigationAbove = (props: Props) => (
    <div
        id={props.id}
        className="custom-navigation-div d-flex justify-content-end"
    >
        <SwiperPrev />
        <SwiperNext />
    </div>
);

export default NavigationAbove;
