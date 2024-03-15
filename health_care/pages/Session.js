import { useEffect } from 'react';

import { useRouter } from 'next/router';

 

export default function SessionCheck() {

    const router = useRouter();

 

    useEffect(() => {

        const session = sessionStorage.getItem('Tkey');

        if (!session) {

            router.push('/');

        }

    }, []);

    // useEffect((user) => {

    //     const session = sessionStorage.getItem('email');

    //     if (!session) {

    //         router.push('/');

    //     }

    // }, [user]);

    return null;

};