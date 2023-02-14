--
-- PostgreSQL database dump
--

-- Dumped from database version 12.1
-- Dumped by pg_dump version 12.1

CREATE DATABASE lean_training;
\c lean_training

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: assemblysteps; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.assemblysteps (
    id integer NOT NULL,
    cost integer NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.assemblysteps OWNER TO postgres;

--
-- Name: partdefinitions; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.partdefinitions (
    id integer NOT NULL,
    cost integer NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.partdefinitions OWNER TO postgres;

--
-- Name: parts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.parts (
    productid integer,
    partdefinitionid integer
);


ALTER TABLE public.parts OWNER TO postgres;

--
-- Name: products; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.products (
    id integer NOT NULL,
    start timestamp without time zone NOT NULL,
    ende timestamp without time zone,
    roundid integer
);


ALTER TABLE public.products OWNER TO postgres;

--
-- Name: rounds; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.rounds (
    id integer NOT NULL,
    start timestamp without time zone NOT NULL,
    ende timestamp without time zone
);


ALTER TABLE public.rounds OWNER TO postgres;

--
-- Name: stations; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.stations (
    id integer NOT NULL,
    "position" character varying(20) NOT NULL,
    roundid integer
);


ALTER TABLE public.stations OWNER TO postgres;

--
-- Name: stationsassemblysteps; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.stationsassemblysteps (
    assemblystepid integer,
    stationid integer
);


ALTER TABLE public.stationsassemblysteps OWNER TO postgres;

--
-- Data for Name: assemblysteps; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.assemblysteps (id, cost, name) FROM stdin;
\.


--
-- Data for Name: partdefinitions; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.partdefinitions (id, cost, name) FROM stdin;
\.


--
-- Data for Name: parts; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.parts (productid, partdefinitionid) FROM stdin;
\.


--
-- Data for Name: products; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.products (id, start, ende, roundid) FROM stdin;
\.


--
-- Data for Name: rounds; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.rounds (id, start, ende) FROM stdin;
\.


--
-- Data for Name: stations; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.stations (id, "position", roundid) FROM stdin;
\.


--
-- Data for Name: stationsassemblysteps; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.stationsassemblysteps (assemblystepid, stationid) FROM stdin;
\.


--
-- Name: assemblysteps assemblysteps_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.assemblysteps
    ADD CONSTRAINT assemblysteps_pkey PRIMARY KEY (id);


--
-- Name: partdefinitions partdefinitions_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.partdefinitions
    ADD CONSTRAINT partdefinitions_pkey PRIMARY KEY (id);


--
-- Name: products products_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (id);


--
-- Name: rounds rounds_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rounds
    ADD CONSTRAINT rounds_pkey PRIMARY KEY (id);


--
-- Name: stations stations_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.stations
    ADD CONSTRAINT stations_pkey PRIMARY KEY (id);


--
-- Name: parts parts_partdefinitionid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.parts
    ADD CONSTRAINT parts_partdefinitionid_fkey FOREIGN KEY (partdefinitionid) REFERENCES public.partdefinitions(id);


--
-- Name: parts parts_productid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.parts
    ADD CONSTRAINT parts_productid_fkey FOREIGN KEY (productid) REFERENCES public.products(id);


--
-- Name: products products_roundid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_roundid_fkey FOREIGN KEY (roundid) REFERENCES public.rounds(id);


--
-- Name: stations stations_roundid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.stations
    ADD CONSTRAINT stations_roundid_fkey FOREIGN KEY (roundid) REFERENCES public.rounds(id);


--
-- Name: stationsassemblysteps stationsassemblysteps_assemblystepid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.stationsassemblysteps
    ADD CONSTRAINT stationsassemblysteps_assemblystepid_fkey FOREIGN KEY (assemblystepid) REFERENCES public.assemblysteps(id);


--
-- Name: stationsassemblysteps stationsassemblysteps_stationid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.stationsassemblysteps
    ADD CONSTRAINT stationsassemblysteps_stationid_fkey FOREIGN KEY (stationid) REFERENCES public.stations(id);


--
-- PostgreSQL database dump complete
--

