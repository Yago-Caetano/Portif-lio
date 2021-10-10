import React from 'react';

import ListItem from './ListItem';

const Listing = (props) =>{
    return(
        <section className="d-flex justify-content-around flex-wrap">
            {props.data.map(e=>{
                return(<ListItem key={e.id} data={e} tags={props.tags}/>)})}
        </section>

    )
}

export default Listing