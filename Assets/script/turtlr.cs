﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turtlr : MonoBehaviour
{
    public Animator anim;
    public Transform player;
    public Rigidbody bullet;
    float health = 10, clk1 = 0.11f, clk2 = 0;
    public float g = 0.8f;
    float dis, clock = 1.1f;
    ParticleSystem PS;
    public ParticleSystem Hurt;
    public Text score;
    AudioSource player_dmg, ene_dmg;
    bool die = false, atk = false;
    void Start()
    {
        PS = GetComponent<ParticleSystem>();
        player_dmg = player.GetComponent<AudioSource>();
        ene_dmg = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (health > 0 && gameObject.GetComponent<Transform>().position.y >= 0)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("start_hit"))
            {
                //anim.SetBool("idle", true);
                anim.SetBool("get_hit", false);

            }
            dis = Vector3.Distance(gameObject.GetComponent<Transform>().position, player.position);
            if (dis <= 14 && dis > 8)
            {
                anim.SetBool("run", true);
                anim.SetBool("idle", false);
                anim.SetBool("atk", false);
                atk = false;
                clk1 = 0.11f;
                clk2 = 0;
                chase();
            }
            else if (dis > 14)
            {
                anim.SetBool("run", false);
                anim.SetBool("idle", true);
                anim.SetBool("atk", false);
                atk = false;
                clk1 = 0.11f;
                clk2 = 0;
            }
            else if (dis <= 8)
            {
                anim.SetBool("run", false);
                anim.SetBool("idle", false);
                anim.SetBool("atk", true);
                atk = true;
                transform.LookAt(player.position);
            }


        }
        else
        {
            anim.SetBool("run", false);
            anim.SetBool("idle", false);
            anim.SetBool("atk", false);
            anim.SetBool("die", true);
            clock -= Time.deltaTime;
            if (clock <= 0)
            {
                anim.speed = 0;
                if (!die)
                {
                    PS.Play(gameObject);
                    die = true;
                    int sc = int.Parse(score.text);
                    sc += 100;
                    score.text = sc.ToString();
                }
                if (clock <= -1.5f) Destroy(gameObject);
            }
        }

    }
    private void FixedUpdate()
    {
        if (atk && health > 0 && gameObject.GetComponent<Transform>().position.y >= 0)
        {
            if (clk1 > 0) clk1 -= Time.deltaTime;
            else
            {
                if (clk2 == 0)
                {
                    Rigidbody rb = Instantiate(bullet, transform.position + transform.forward + transform.up * 1.1f, Quaternion.identity);
                    rb.transform.forward = transform.forward;
                    clk2 = 0.01f;
                }
                else
                {
                    clk2 += Time.deltaTime;
                    if (clk2 >= g) clk2 = 0;
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "fire")
        {
            anim.SetBool("get_hit", true);
            ene_dmg.PlayOneShot(ene_dmg.clip);
            health -= 2;
            Hurt.Clear();
            Hurt.Play();

        }
        if (other.gameObject.tag == "steel")
        {
            anim.SetBool("get_hit", true);
            ene_dmg.PlayOneShot(ene_dmg.clip);
            health -= 4;
            Hurt.Play();
            Hurt.Clear();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "earth")
        {
            gameObject.GetComponent<Rigidbody>().velocity = transform.up * 10f - transform.forward * 4;
            health -= 0.5f;
            ene_dmg.PlayOneShot(ene_dmg.clip);
            Hurt.Play();
            Hurt.Clear();
        }
    }

    void chase()
    {
        Vector3 pos;
        pos = gameObject.GetComponent<Transform>().position;
        transform.LookAt(player.position);
        transform.position += transform.forward * 1.5f * Time.deltaTime;
    }
}
