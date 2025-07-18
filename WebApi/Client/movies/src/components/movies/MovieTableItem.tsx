import { Button } from "semantic-ui-react";

import type { MovieDto } from "../../models/movieDto";
import apiConnector from "../../api/apiConnector";
import { NavLink } from "react-router-dom";

interface Props {
    movie: MovieDto;
}

export default function MovieTableItem({movie}: Props) {
    return (
        <>
            <tr className="center aligned">
                <td data-lable="Id">{movie.id}</td>
                <td data-lable="Title">{movie.title}</td>
                <td data-lable="Description">{movie.description}</td>
                <td data-lable="Create Date">{movie.createDate}</td>
                <td data-lable="Category">{movie.category}</td>
                <td data-lable="Action">
                    <Button as={NavLink} to={`editMovie/${movie.id}`} color="yellow" type="submit">
                        Edit
                    </Button>
                    <Button type="button" negative onClick={async () => {
                        await apiConnector.deleteMovie(movie.id!);
                        window.location.reload();
                    }}>
                        Delete
                    </Button>

                </td>

            </tr>
        </>
    )
}