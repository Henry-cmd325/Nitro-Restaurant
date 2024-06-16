import { useState, useEffect } from 'react';
// Firebase
import { collection, onSnapshot, query, orderBy } from 'firebase/firestore';
import { db } from '../config/firebase';

const useOrderTypes = () => {
    const [orderTypes, setOrderTypes] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const Query = query(collection(db, 'tipo_pedidos'), orderBy('nombre'));

        const unsubscribe = onSnapshot(Query, (snapshot) => {
            const List = snapshot.docs.map(doc => {
                const data = doc.data();

                return {
                    id: doc.id,
                    ...data
                };
            });
            setOrderTypes(List);
            setLoading(false);
        }, (error) => {
            console.error('Error listening to mesas:', error);
            setError(error);
            setLoading(false);
        });

        return () => {
            unsubscribe();
        };
    }, []);

    return { orderTypes, loading, error };
};

export default useOrderTypes;