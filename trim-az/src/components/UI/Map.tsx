import { useMemo } from "react";
import { GoogleMap, useLoadScript, Marker } from "@react-google-maps/api";

type PropsType = {
    lat: number;
    lng: number;
};

const Map = (props: PropsType) => {
    const center = useMemo(
        () => ({ lat: props.lat, lng: props.lng }),
        [props.lat, props.lng]
    );

    const { isLoaded } = useLoadScript({
        googleMapsApiKey: "AIzaSyDDy4oCPjx23wQeEJpV3D2uITVu5N3eFIs",
    });

    if (!isLoaded) return <div>Loading...</div>;

    return (
        <GoogleMap zoom={18} center={center} mapContainerClassName="map">
            <Marker position={center} />
        </GoogleMap>
    );
};

export default Map;
